using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Project.Services
{
    public interface IBrowser
    {
        Task OpenAsync(string uri);
        Task OpenAsync(string uri, BrowserLaunchMode launchMode);
        Task OpenAsync(string uri, BrowserLaunchOptions options);
        Task OpenAsync(Uri uri);
        Task OpenAsync(Uri uri, BrowserLaunchMode launchMode);
        Task<bool> OpenAsync(Uri uri, BrowserLaunchOptions options);
    }

    public interface IPreferences
    {
        bool ContainsKey(string key);
        void Remove(string key);
        void Clear();
        string Get(string key, string defaultValue);
        bool Get(string key, bool defaultValue);
        int Get(string key, int defaultValue);
        double Get(string key, double defaultValue);
        float Get(string key, float defaultValue);
        long Get(string key, long defaultValue);
        void Set(string key, string value);
        void Set(string key, bool value);
        void Set(string key, int value);
        void Set(string key, double value);
        void Set(string key, float value);
        void Set(string key, long value);
        bool ContainsKey(string key, string sharedName);
        void Remove(string key, string sharedName);
        void Clear(string sharedName);
        string Get(string key, string defaultValue, string sharedName);
        bool Get(string key, bool defaultValue, string sharedName);
        int Get(string key, int defaultValue, string sharedName);
        double Get(string key, double defaultValue, string sharedName);
        float Get(string key, float defaultValue, string sharedName);
        long Get(string key, long defaultValue, string sharedName);
        void Set(string key, string value, string sharedName);
        void Set(string key, bool value, string sharedName);
        void Set(string key, int value, string sharedName);
        void Set(string key, double value, string sharedName);
        void Set(string key, float value, string sharedName);
        void Set(string key, long value, string sharedName);
        DateTime Get(string key, DateTime defaultValue);
        void Set(string key, DateTime value);
        DateTime Get(string key, DateTime defaultValue, string sharedName);
        void Set(string key, DateTime value, string sharedName);
    }

    public interface IShare
    {
        Task RequestAsync(string text);
        Task RequestAsync(string text, string title);
        Task RequestAsync(ShareTextRequest request);
        Task RequestAsync(ShareFileRequest request);
    }


    class ImplementationEssentials
    {
        public ImplementationEssentials()
        {
        }
    }

    public class BrowserImplementation : IBrowser
    {

        Task IBrowser.OpenAsync(string uri)
             => Xamarin.Essentials.Browser.OpenAsync(uri);

        Task IBrowser.OpenAsync(string uri, BrowserLaunchMode launchMode)
             => Xamarin.Essentials.Browser.OpenAsync(uri, launchMode);

        Task IBrowser.OpenAsync(string uri, BrowserLaunchOptions options)
             => Xamarin.Essentials.Browser.OpenAsync(uri, options);

        Task IBrowser.OpenAsync(Uri uri)
             => Xamarin.Essentials.Browser.OpenAsync(uri);

        Task IBrowser.OpenAsync(Uri uri, BrowserLaunchMode launchMode)
             => Xamarin.Essentials.Browser.OpenAsync(uri, launchMode);

        Task<bool> IBrowser.OpenAsync(Uri uri, BrowserLaunchOptions options)
             => Xamarin.Essentials.Browser.OpenAsync(uri, options);
    }

    public class PreferencesImplementation : IPreferences
    {

        bool IPreferences.ContainsKey(string key)
             => Xamarin.Essentials.Preferences.ContainsKey(key);

        void IPreferences.Remove(string key)
             => Xamarin.Essentials.Preferences.Remove(key);

        void IPreferences.Clear()
             => Xamarin.Essentials.Preferences.Clear();

        string IPreferences.Get(string key, string defaultValue)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue);

        bool IPreferences.Get(string key, bool defaultValue)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue);

        int IPreferences.Get(string key, int defaultValue)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue);

        double IPreferences.Get(string key, double defaultValue)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue);

        float IPreferences.Get(string key, float defaultValue)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue);

        long IPreferences.Get(string key, long defaultValue)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue);

        void IPreferences.Set(string key, string value)
             => Xamarin.Essentials.Preferences.Set(key, value);

        void IPreferences.Set(string key, bool value)
             => Xamarin.Essentials.Preferences.Set(key, value);

        void IPreferences.Set(string key, int value)
             => Xamarin.Essentials.Preferences.Set(key, value);

        void IPreferences.Set(string key, double value)
             => Xamarin.Essentials.Preferences.Set(key, value);

        void IPreferences.Set(string key, float value)
             => Xamarin.Essentials.Preferences.Set(key, value);

        void IPreferences.Set(string key, long value)
             => Xamarin.Essentials.Preferences.Set(key, value);

        bool IPreferences.ContainsKey(string key, string sharedName)
             => Xamarin.Essentials.Preferences.ContainsKey(key, sharedName);

        void IPreferences.Remove(string key, string sharedName)
             => Xamarin.Essentials.Preferences.Remove(key, sharedName);

        void IPreferences.Clear(string sharedName)
             => Xamarin.Essentials.Preferences.Clear(sharedName);

        string IPreferences.Get(string key, string defaultValue, string sharedName)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);

        bool IPreferences.Get(string key, bool defaultValue, string sharedName)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);

        int IPreferences.Get(string key, int defaultValue, string sharedName)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);

        double IPreferences.Get(string key, double defaultValue, string sharedName)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);

        float IPreferences.Get(string key, float defaultValue, string sharedName)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);

        long IPreferences.Get(string key, long defaultValue, string sharedName)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);

        void IPreferences.Set(string key, string value, string sharedName)
             => Xamarin.Essentials.Preferences.Set(key, value, sharedName);

        void IPreferences.Set(string key, bool value, string sharedName)
             => Xamarin.Essentials.Preferences.Set(key, value, sharedName);

        void IPreferences.Set(string key, int value, string sharedName)
             => Xamarin.Essentials.Preferences.Set(key, value, sharedName);

        void IPreferences.Set(string key, double value, string sharedName)
             => Xamarin.Essentials.Preferences.Set(key, value, sharedName);

        void IPreferences.Set(string key, float value, string sharedName)
             => Xamarin.Essentials.Preferences.Set(key, value, sharedName);

        void IPreferences.Set(string key, long value, string sharedName)
             => Xamarin.Essentials.Preferences.Set(key, value, sharedName);

        DateTime IPreferences.Get(string key, DateTime defaultValue)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue);

        void IPreferences.Set(string key, DateTime value)
             => Xamarin.Essentials.Preferences.Set(key, value);

        DateTime IPreferences.Get(string key, DateTime defaultValue, string sharedName)
             => Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);

        void IPreferences.Set(string key, DateTime value, string sharedName)
             => Xamarin.Essentials.Preferences.Set(key, value, sharedName);
    }

    public class ShareImplementation : IShare
    {

        Task IShare.RequestAsync(string text)
             => Xamarin.Essentials.Share.RequestAsync(text);

        Task IShare.RequestAsync(string text, string title)
             => Xamarin.Essentials.Share.RequestAsync(text, title);

        Task IShare.RequestAsync(ShareTextRequest request)
             => Xamarin.Essentials.Share.RequestAsync(request);

        Task IShare.RequestAsync(ShareFileRequest request)
             => Xamarin.Essentials.Share.RequestAsync(request);
    }
}
