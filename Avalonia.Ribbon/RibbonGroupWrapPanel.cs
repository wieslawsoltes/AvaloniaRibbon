﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Avalonia.Layout;

namespace Avalonia.Controls.Ribbon
{
    public class RibbonGroupWrapPanel : WrapPanel
    {
        bool _smallified = false;
        Size _prevSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
        protected override Size MeasureOverride(Size constraint)
        {
            double newConsWidth = constraint.Width;
            double newConsHeight = constraint.Height;
            /*if (!double.IsFinite(constraint.Width))
                newConsWidth = 0;
            if (!double.IsFinite(constraint.Height))
                newConsHeight = 0;*/


            var children = Children.Where(x => x is IRibbonControl);
            foreach (IRibbonControl ctrl in children)
                ctrl.Size = ctrl.MaxSize;

            //double _prevSize.Width
            

            Size bigSize = base.MeasureOverride(constraint);
            Size desired = _prevSize;
            if (desired.Width <= 0)
                desired = desired.WithWidth(bigSize.Width);
            if (desired.Height <= 0)
                desired = desired.WithHeight(bigSize.Height);
            _prevSize = bigSize;
            
            bool proceed = (desired.Width >= 0) || (desired.Height >= 0);
            //Debug.WriteLine("bigSize: " + bigSize + "\ndesired: " + desired + "\nnewCons: " + newConsWidth + ", " + newConsHeight + "\nproceed: " + proceed);

            if (double.IsInfinity(newConsWidth) || double.IsInfinity(newConsHeight))
                return bigSize;
            if (proceed &&
                    (
                        ((Orientation == Orientation.Vertical) && (desired.Width > newConsWidth)) ||
                        ((Orientation == Orientation.Horizontal) && (desired.Height > newConsHeight))
                    )
                )
            {
                foreach (IRibbonControl ctrl in children)
                    ctrl.Size = ctrl.MinSize;

                Size smallSize = base.MeasureOverride(constraint);
                Size arrSize = ArrangeOverride(smallSize);
                double newWidth = smallSize.Width;
                double newHeight = smallSize.Height;
                /*if (Orientation == Orientation.Vertical)
                    newWidth = Math.Min(smallSize.Width, desired.Width);
                else
                    newHeight = Math.Min(smallSize.Height, desired.Height);*/

                if (!_smallified)
                {
                    //Debug.WriteLine("Smallified!");
                    _smallified = true;
                }
                return arrSize; //smallSize; //new Size(Math.Max(newWidth, MinWidth), Math.Max(newHeight, MinHeight));
            }
            else
            {
                ArrangeOverride(bigSize);
                return bigSize;
            }

            if (false)
            {
                /*_prevSize = base.MeasureOverride(constraint);
                return _prevSize;*/
                ////var bigSize = base.MeasureOverride(constraint);
                double prevWidth = _prevSize.Width;
                double prevHeight = _prevSize.Height;
                Debug.WriteLine(prevWidth + ", " + prevHeight);
                _prevSize = bigSize;

                if (Orientation == Layout.Orientation.Vertical)
                {
                    if (bigSize.Width < prevWidth)
                    {
                        foreach (IRibbonControl ctrl in children)
                            ctrl.Size = ctrl.MinSize;

                        return base.MeasureOverride(constraint);
                    }
                }
                else if (Orientation == Layout.Orientation.Horizontal)
                {

                    if (bigSize.Height < prevHeight)
                    {
                        foreach (IRibbonControl ctrl in children)
                            ctrl.Size = ctrl.MinSize;

                        return base.MeasureOverride(constraint);
                    }
                }

                return bigSize;
            }
        }

        /*protected override Size ArrangeOverride(Size finalSize)
        {
            var children = Children.Where(x => x is IRibbonControl);
            foreach (IRibbonControl ctrl in children)
                ctrl.Size = ctrl.MaxSize;

            var bigSize = base.ArrangeOverride(finalSize);
            //return bigSize;
            double prevWidth = finalSize.Width;
            double prevHeight = finalSize.Height;
            Debug.WriteLine(prevWidth + ", " + prevHeight);
            if ((Orientation == Layout.Orientation.Vertical) && double.IsFinite(prevWidth))
            {
                if (bigSize.Width > prevWidth)
                {
                    foreach (IRibbonControl ctrl in children)
                        ctrl.Size = ctrl.MinSize;

                    return base.ArrangeOverride(finalSize);
                }
            }
            else if ((Orientation == Layout.Orientation.Horizontal) && double.IsFinite(prevHeight))
            {

                if (bigSize.Height > prevHeight)
                {
                    foreach (IRibbonControl ctrl in children)
                        ctrl.Size = ctrl.MinSize;

                    return base.ArrangeOverride(finalSize);
                }
            }
            return bigSize;
        }*/
    }
}