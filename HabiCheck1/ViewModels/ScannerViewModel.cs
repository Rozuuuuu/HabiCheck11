using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HabiCheck.Models;
using HabiCheck.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabiCheck.ViewModels;

public partial class ScannerViewModel : BaseViewModel
{
    private readonly IFabricAnalyzerService _analyzer;
    private readonly DatabaseService _db;

    [ObservableProperty]
    private bool _isScanning;

    [ObservableProperty]
    private bool _flashOn;

    [ObservableProperty]
    private string _statusText = "Point camera at fabric weave";

    public ScannerViewModel(IFabricAnalyzerService analyzer, DatabaseService db)
    {
        _analyzer = analyzer;
        _db = db;
    }

    [RelayCommand]
    private async Task CaptureAndScanAsync()
    {
        if (IsBusy) return;

        try
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync(
                new MediaPickerOptions { Title = "Scan Fabric" });

            // Pass true to save camera captures to the DB
            await ProcessPhotoAsync(photo, saveToDb: true);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    [RelayCommand]
    private async Task PickFromGalleryAsync()
    {
        if (IsBusy) return;

        try
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();

            // Assuming you also want to save gallery scans. If not, change to false.
            await ProcessPhotoAsync(photo, saveToDb: true);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }

    [RelayCommand]
    private void ToggleFlash() => FlashOn = !FlashOn;

    /// <summary>
    /// Centralized logic for processing the image stream, analyzing, saving, and navigating.
    /// </summary>
    private async Task ProcessPhotoAsync(FileResult? photo, bool saveToDb)
    {
        if (photo is null) return;

        IsBusy = true;
        IsScanning = true;
        StatusText = "Analyzing fiber structure...";

        try
        {
            await using var stream = await photo.OpenReadAsync();

            var hulasLevel = Preferences.Get("hulas_level", "pawisin");
            var result = await _analyzer.AnalyzeAsync(stream, hulasLevel);

            if (saveToDb)
            {
                await _db.SaveScanAsync(new ScanRecord
                {
                    FabricName = result.Name,
                    Grade = result.Grade,
                    FiberType = result.FiberType,
                    ImagePath = photo.FullPath,
                    ScannedAt = DateTime.Now
                });
            }

            // Use dictionary parameters to safely pass complex objects to the next page
            var navigationParams = new Dictionary<string, object>
            {
                { "ResultData", result },
                { "ResultType", result.IsSuccess ? "success" : "warning" }
            };

            await Shell.Current.GoToAsync(nameof(Views.ResultPage), navigationParams);
        }
        finally
        {
            // Always reset the UI state, even if an exception occurs during analysis
            ResetState();
        }
    }

    private async Task HandleErrorAsync(Exception ex)
    {
        // TODO: Add telemetry/logging here (e.g., AppCenter.Crashes.TrackError)
        ResetState();
        await Shell.Current.DisplayAlert("Scan Error", ex.Message, "OK");
    }

    private void ResetState()
    {
        IsBusy = false;
        IsScanning = false;
        StatusText = "Point camera at fabric weave";
    }
}