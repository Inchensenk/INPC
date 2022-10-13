using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace INPC
{
    public class PersonModel : ObservableObject
    {
		private string _name;

		public string Name
		{
			get { return _name; }
			set 
			{ 
				_name = value;
                OnPropertyChanged();// так как мы используем атрибут [CallerMemberName], то не нужно явно задавать свойство Name в параметре
            }
		}

		public PersonModel()
		{
			//Создание пулла потоков
			Task.Run(() => 
			{
				while (true)
				{
					//Random rnd = new Random();
					//Name = rnd.Next(1,1000).ToString();

					Debug.WriteLine($"Name: {Name}");
					//худший способ заставить поток спать, но для тестирования пойдет
					Thread.Sleep(500);
				}
			});
		}

	}
}


