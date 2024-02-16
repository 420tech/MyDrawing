namespace MyDrawing.ViewModels;

public partial class SettingViewModel : BaseViewModel
{
    [ObservableProperty]
    bool isRecording = true;

    [ObservableProperty]
    string dataPath = string.Empty;
}
