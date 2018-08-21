using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RagnarokOnlineItemViewer
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void SetPropertyAndRaise<T>( ref T member, T value, [CallerMemberName] string propertyName = null )
        {
            if( Equals( member, value ) ) return;

            member = value;
            OnPropertyChanged( propertyName );
        }

        protected virtual void OnPropertyChanged( string propertyName ) 
            => PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
    }
}
