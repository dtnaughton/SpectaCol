using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectaCol.ViewModels
{
  public static class ViewModelUtilities
  {
    public static string UpdatedTimeAgo(string timestamp)
    {
      TimeSpan timeAgo;
      try
      {
        timeAgo = DateTime.Now.Subtract(DateTime.Parse(timestamp));
      }
      catch (FormatException e)
      {
        return "never";
      }

      if (timeAgo.TotalSeconds < 60)
        return "just now";
      if (timeAgo.TotalMinutes < 60)
        return $"{timeAgo.Minutes} minute{PluralS(timeAgo.Minutes)} ago";
      if (timeAgo.TotalHours < 24)
        return $"{timeAgo.Hours} hour{PluralS(timeAgo.Hours)} ago";
      if (timeAgo.TotalDays < 7)
        return $"{timeAgo.Days} day{PluralS(timeAgo.Days)} ago";
      if (timeAgo.TotalDays < 30)
        return $"{timeAgo.Days / 7} week{PluralS(timeAgo.Days / 7)} ago";
      if (timeAgo.TotalDays < 365)
        return $"{timeAgo.Days / 30} month{PluralS(timeAgo.Days / 30)} ago";

      return $"{timeAgo.Days / 356} year{PluralS(timeAgo.Days / 356)} ago";
    }
    public static string PluralS(int num)
    {
      return num != 1 ? "s" : "";
    }
  }
}
