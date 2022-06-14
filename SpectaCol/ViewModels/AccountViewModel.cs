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
    public AccountViewModel(Account account)
    {
      _account = account;
    }
  }
}

