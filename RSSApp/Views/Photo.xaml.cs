namespace RSSApp.Views;

public partial class Photo : ContentPage
{
    public int _InspEquipID;
	public Photo(int InspEquipID)
	{
		InitializeComponent();
        _InspEquipID = InspEquipID;

    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        TakePhoto();
    }

    public async void TakePhoto()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);
            }
        }
    }
}
