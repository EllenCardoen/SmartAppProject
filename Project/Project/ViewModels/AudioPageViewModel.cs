﻿using Android.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ViewModels
{
    public class AudioPageViewModel : ViewModelBase
    {
        private ICustomNavigation _navigationService;
        protected MediaPlayer player;
        private IProjectAppService _projectAppService;

        public AudioPageViewModel(ICustomNavigation navigationService, IProjectAppService projectAppService)
        {
            _navigationService = navigationService;
            _projectAppService = projectAppService;
        }

        

        private Track _selectedTrack;
        public Track SelectedTrack
        {
            get
            {
                return _selectedTrack;
            }
            set
            {
                _selectedTrack = value;
                RaisePropertyChanged(() => SelectedTrack);
                Id = _selectedTrack.id;
                Image = _selectedTrack.album_image;
                Name = _selectedTrack.name;
                Audio = _selectedTrack.audio;
                ArtistName = _selectedTrack.artist_name;
                Duration = _selectedTrack.duration;
                ShortUrl = _selectedTrack.shorturl;
            }
        }

        

        public void MakePlayer(string filePath)
        {
            if (player == null)
            {
                player = new MediaPlayer();
                player.Reset();
                player.SetDataSource(filePath);
                player.Prepare();
                player.Start();
            }
        }

        public RelayCommand startTrack
        {
            get
            {
                return new RelayCommand(() =>
                {

                    MakePlayer(Audio);
                });
            }
        }

        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            } 
        }

        private string _image;
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                RaisePropertyChanged(() => Image);
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private string _audio;
        public string Audio
        {
            get
            {
                return _audio;
            }
            set
            {
                _audio = value;
                RaisePropertyChanged(() => Audio);
            }
        }

        private string _artistName;
        public string ArtistName
        {
            get
            {
                return _artistName;
            }
            set
            {
                _artistName = value;
                RaisePropertyChanged(() => ArtistName);
            }
        }

        private int _duration;
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                RaisePropertyChanged(() => Duration);
            }
        }

        private string _shortUrl;
        public string ShortUrl
        {
            get
            {
                return _shortUrl;
            }
            set
            {
                _shortUrl = value;
                RaisePropertyChanged(() => ShortUrl);
            }
        }

        private int _slider;
        public int Slider
        {
            get
            {
                return _slider;
            }
            set
            {
                _slider = Duration;
                RaisePropertyChanged(() => Slider);
                
            }
        }

        public RelayCommand shareTrack
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _projectAppService.ShareContent(ShortUrl);
                });
            }
        }

        public RelayCommand addTrack
        {
            get
            {
                return new RelayCommand(() =>
                {
                    DatabaseIdContent idForDatabase = new DatabaseIdContent();
                    idForDatabase.id = Id;
                    _projectAppService.AddTrackMySongs(idForDatabase);
                });
            }
        }

        

    }
}
