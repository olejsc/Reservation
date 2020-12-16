using System;
using System.Collections;
using System.Collections.Generic;

namespace Reservation
{
    public class HotelFloor : IEnumerable<ARoom>
    {
        /// <summary>
        /// A array of all the rooms this place have.
        /// </summary>
        private ARoom[] _rooms;

        public HotelFloor (ARoom[] rooms)
        {
            _rooms = rooms ?? throw new ArgumentOutOfRangeException(nameof(rooms), "Must be more than 0 rooms in this place.");
        }

        public IEnumerator<ARoom> GetEnumerator ()
        {
            return new RoomEnumerator(_rooms);
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return _rooms.GetEnumerator();
        }

        private class RoomEnumerator : IEnumerator<ARoom>
        {
            private ARoom[] _rooms;
            private int _currentIndex;

            public RoomEnumerator (ARoom[] rooms)
            {
                _rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
            }

            public ARoom Current
            {
                get
                {
                    try { return _rooms[_currentIndex]; }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current { get { return Current; } }

            public void Dispose ()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext ()
            {
                _currentIndex++;
                return (_currentIndex < _rooms.Length);
            }

            public void Reset ()
            {
                _currentIndex = -1;
            }
        }
    }
}