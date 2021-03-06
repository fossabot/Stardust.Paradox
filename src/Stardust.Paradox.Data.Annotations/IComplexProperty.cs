﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Stardust.Paradox.Data.Annotations.Annotations;

namespace Stardust.Paradox.Data.Annotations
{
    public abstract class IComplexProperty : INotifyPropertyChanged
    {
        private bool _notify;
        public event PropertyChangedEventHandler PropertyChanged;

        [Obsolete("internal use only", false)]
        public void StartNotifications()
        {
            _notify = true;
        }

        [Obsolete("internal use only", false)]
        public void EndNotifications()
        {
            _notify = false;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (_notify)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return GetEqualityValue();
        }

        protected virtual string GetEqualityValue()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}