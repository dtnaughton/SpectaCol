using Avalonia.Media.Imaging;
using Speckle.Core.Credentials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public class AccountViewModel : ViewModelBase
  {
    private Account _account;
    public string ServerName => _account.serverInfo.name;
    public string ServerUrl => _account.serverInfo.url;
    public string Username => _account.userInfo.name;
    public string Email => _account.userInfo.email;
    public string Id => _account.id;
    private Bitmap _avatarImage;
    public Bitmap AvatarImage
    {
      get => _avatarImage;
      set
      {
        _avatarImage = value;
        OnPropertyChanged(nameof(AvatarImage));
      }
    }

    public AccountViewModel(Account account)
    {
      _account = account;

      DownloadAvatarImage(_account.userInfo.avatar);
    }

    private void DownloadAvatarImage(string url)
    {
      if (string.IsNullOrEmpty(url))
        return;

      using (WebClient client = new WebClient())
      {
        client.DownloadDataAsync(new Uri(url));
        client.DownloadDataCompleted += DownloadComplete;
      }
    }

    private void DownloadComplete(object sender, DownloadDataCompletedEventArgs e)
    {
        byte[] bytes = e.Result;

        System.IO.Stream stream = new MemoryStream(bytes);

        var image = new Avalonia.Media.Imaging.Bitmap(stream);
        AvatarImage = image;
        OnPropertyChanged(nameof(AvatarImage));
    }

  }
}

