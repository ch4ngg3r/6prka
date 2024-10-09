using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6prka
{
    public partial class MainWindow : Window
    {
        private int[] _array;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int length = random.Next(1, 20); // Генерируем длину массива от 1 до 19
            _array = new int[length];
            for (int i = 0; i < length; i++)
            {
                _array[i] = random.Next(-100, 101); // Генерируем случайные числа от -100 до 100
            }
            GeneratedArrayBox.Text = string.Join(", ", _array); // Отображаем сгенерированный массив

            int[] sortedArray;
            if (BubbleSortRadioButton.IsChecked == true)
            {
                sortedArray = BubbleSort((int[])_array.Clone()); // Сортировка пузырьком
            }
            else if (InsertionSortRadioButton.IsChecked == true)
            {
                sortedArray = InsertionSort((int[])_array.Clone()); // Сортировка вставками
            }
            else if (QuickSortRadioButton.IsChecked == true)
            {
                sortedArray = QuickSort((int[])_array.Clone(), 0, _array.Length - 1); // Быстрая сортировка
            }
            else
            {
                sortedArray = SelectionSort((int[])_array.Clone()); // Сортировка выбором
            }

            SortedArrayBox.Text = string.Join(", ", sortedArray); // Отображаем отсортированный массив
        }

        // Сортировка пузырьком
        private int[] BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Меняем местами
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }

        // Сортировка вставками
        private int[] InsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                // Перемещаем элементы, которые больше ключа, на одну позицию вперед
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            return array;
        }

        // Быстрая сортировка
        private int[] QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSort(array, low, pi - 1); // Рекурсивно сортируем элементы до и после разделителя
                QuickSort(array, pi + 1, high);
            }
            return array;
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high]; // Опорный элемент
            int i = (low - 1); // Индекс меньшего элемента
            for (int j = low; j < high; j++)
            {
                // Если текущий элемент меньше или равен опорному
                if (array[j] <= pivot)
                {
                    i++;
                    // Меняем местами
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            // Меняем местами опорный элемент с элементом, который больше него
            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;
            return i + 1;
        }

        // Сортировка выбором
        private int[] SelectionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                // Меняем местами минимальный элемент с текущим элементом
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
            return array;
        }
    }
}