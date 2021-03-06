﻿using System;
using System.Windows.Data;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnlineBus
{
    public class ChangeBusTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strResult = "";
            ObservableCollection<Segment> segments = (ObservableCollection<Segment>)value;
            strResult += segments[0].LineName;
            for (int i = 1; i < segments.Count; i++ )
            {
                strResult += " → " + segments[i].LineName;
            }
            
            return strResult;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ChangeBusCountConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "换乘" + (int)value + "次,";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ChangeBusTimeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int time = int.Parse((string)value);
            if(time < 60)
            {
                return "用时约" + time + "分钟,";
            }
            else
            {
                return "用时约" + time/60 + "小时" + time%60 + "分钟,";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ChangeBusDistanceConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int distance = int.Parse((string)value);
            if(distance <= 1000)
            {
                return "距离约" + distance + "米";
            }
            else
            {
                return "距离约" + (distance/1000.0).ToString("0.0") + "公里";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class RouteDetailFootDistanceConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (int.Parse((string)value) == 0)
            //{
            //    return "在此站乘坐";
            //}
            //else
            //{
                return "步行" + (string)value + "米到";
            //}
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class RouteDetailStatCountConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "(" + (int)value + "站)到";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class LineNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strOrigin = (string)value;
            string lineName = strOrigin.Substring(0, strOrigin.IndexOf('('));
            return lineName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class LineStartAndEndConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strOrigin = (string)value;
            int start = strOrigin.IndexOf('(') + 1;
            int end = strOrigin.Length - 1;
            string strStartAndEnd = strOrigin.Substring(start, end - start);
            return strStartAndEnd;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class LineTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string strOrigin = (string)value;
            string strTime = "";
            if(strOrigin.Length > 0)
            {
                string[] infos = strOrigin.Split(';');
                if(infos.Length > 2)
                    strTime = infos[1];
            }
            return strTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}