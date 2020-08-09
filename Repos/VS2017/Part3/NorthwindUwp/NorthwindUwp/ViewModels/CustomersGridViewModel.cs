﻿using System;
using System.Collections.ObjectModel;

using NorthwindUwp.Helpers;
using NorthwindUwp.Models;
using NorthwindUwp.Services;

namespace NorthwindUwp.ViewModels
{
    public class CustomersGridViewModel : Observable
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}
