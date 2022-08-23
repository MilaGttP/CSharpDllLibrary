
namespace ArrayLibrary
{
    public class Array
    {
        private double[] array { get; set; }
        int counter;
        public Array()
        {
            array = new double[0]; counter = 0; 
        }
        public Array(double[] arr)
        {
            array = arr; counter = 0;
        }
        public string GetEven ()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            foreach (int item in array)
                if (item % 2 == 0) stringBuilder.Append(item);
            return stringBuilder.ToString();
        }
        public string GetOdd()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            foreach (int item in array)
                if (item % 2 != 0) stringBuilder.Append(item);
            return stringBuilder.ToString();
        }
        public int Less(int valueToCompare)
        {
            foreach (int item in array)
                if (item < valueToCompare) counter++;
            return counter;
        }
        public int Greater(int valueToCompare)
        {
            foreach (int item in array)
                if (item > valueToCompare) counter++;
            return counter;
        }
        public int CountDistinct()
        {
            return counter = array.Where(t => array.Count(t.Equals) == 1).Count();
        }
        public int EqualToValue(int valueToCompare)
        {
            foreach (int item in array)
                if (item == valueToCompare) counter++;
            return counter;
        }
    }
}