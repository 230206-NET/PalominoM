using System; 

namespace CoinFlipper{

	public class Flipper{
		
		public static void Main(string[] agrs){
			
			Random random = new Random();
			var r = random.Next();
			int remainder = r % 2; 
			if(remainder == 0){
			 Console.WriteLine("heads");
			} else{
			 Console.WriteLine("tails");
			}
		
		}


	}



}
