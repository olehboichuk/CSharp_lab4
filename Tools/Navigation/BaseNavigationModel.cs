﻿using System.Collections.Generic;

namespace Csharp_laba2.Tools
{
    internal abstract class BaseNavigationModel : INavigationModel
    {
        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;

        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner
        {
            get { return _contentOwner; }
        }

        protected Dictionary<ViewType, INavigatable> ViewsDictionary
        {
            get { return _viewsDictionary; }
        }

        public void Navigate(ViewType viewType)
        {
            if (ViewsDictionary.ContainsKey(viewType))
                ViewsDictionary.Remove(viewType);
            InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
        }

        protected abstract void InitializeView(ViewType viewType);

    }
}