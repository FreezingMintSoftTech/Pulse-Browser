﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Pulse_Browser.Services
{
    public class Bookmark
    {
        public Uri Uri { get; set; }
        public BitmapImage Icon { get; set; }
    }

    public static class BookmarksService
    {
        public static async Task<List<Bookmark>> GetBookmarks()
        {
            List<Bookmark> Bookmarks = (await Helpers.Storage.GetLocalClass<List<Bookmark>>("SavedBookmarks")) ?? DefaultBookmarks;

            return Bookmarks;
        }

        public static async Task AddBookmark(Bookmark bookmark)
        {
            await AddBookmark(bookmark, 0);
        }

        public static async Task AddBookmark(Bookmark bookmark, int index)
        {
            List<Bookmark> Bookmarks = (await Helpers.Storage.GetLocalClass<List<Bookmark>>("SavedBookmarks")) ?? DefaultBookmarks;
            Bookmarks.Insert(0, bookmark);

            await Helpers.Storage.StoreLocalClass("Bookmarks", Bookmarks);
        }

        private static List<Bookmark> DefaultBookmarks = new List<Bookmark>()
        {
            new Bookmark()
            {
                Uri = new Uri("https://google.com/"),
                Icon = new BitmapImage() {UriSource = new Uri($"http://www.google.com/s2/favicons?domain=google.com")},
            },
            new Bookmark()
            {
                Uri = new Uri("https://linkedin.com/"),
                Icon = new BitmapImage() {UriSource = new Uri($"http://www.google.com/s2/favicons?domain=linkedin.com")},
            },
            new Bookmark()
            {
                Uri = new Uri("https://youtube.com/"),
                Icon = new BitmapImage() {UriSource = new Uri($"http://www.google.com/s2/favicons?domain=youtube.com")},
            }
        };
    }
}
