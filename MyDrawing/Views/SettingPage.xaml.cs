namespace MyDrawing.Views;

public partial class SettingPage : ContentPage
{
    private readonly SettingViewModel viewModel;

    public SettingPage(SettingViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();

        });
    }

    private async void takePhoto_Clicked(object sender, EventArgs e)
    {
        //myImage.Source = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
        var dataPath = Path.Combine(FileSystem.AppDataDirectory, "myImage.png");
        Debug.WriteLine(dataPath);
        await cameraView.SaveSnapShot(Camera.MAUI.ImageFormat.PNG, dataPath);
        await cameraView.StopCameraAsync();
        viewModel.IsRecording = false;
        viewModel.DataPath = dataPath;
    }
}
