namespace Reservation
{
    public abstract class ABed
    {
        public abstract string Name { get; }

        public abstract int AdultCapacity { get; init; }

        public abstract bool CanMergeWithOtherBed ();

        public abstract bool SupportHandicap { get; init; }

        public abstract float BasePrice { get; init; }

        public abstract float CompositePrice (ABed otherBed);

        public abstract float TotalPrice (float[] modifiers);

        public abstract ABed Merge (ABed bedToMerge);
    }
}