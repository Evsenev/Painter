using System;
using System.IO;
using System.Collections;

namespace Painter
{

	class Rectangle
	{
		public int x1,y1,x2,y2;
		public Rectangle (int a, int b, int c, int d){
			x1 = a;
			y1 = b;
			x2 = c;
			y2 = d;
		}
	}

	class Canvas
		{
		public string [] data;
		public int [] aboutRect;
		public int CanvasWidth, CanvasHeigth, RectCount, PaintedArea, EmptyArea;
		public int[,] CommonArea;



		public void ReadInputFile ()
		{
			string InputData = System.IO.File.OpenText("INPUT.txt").ReadToEnd().Trim();
			data = InputData.Replace ("\r\n", ";").Split (' ', ';', '\n');

			int[] nums = new int[data.Length];

			for (int i = 0; i < data.Length; i++) {
				nums [i] = Convert.ToInt32 (data [i]);
			}

			aboutRect = nums;

			CanvasWidth = aboutRect [0];
			CanvasHeigth = aboutRect [1];
			RectCount = aboutRect [2];

			CommonArea = new int[CanvasWidth, CanvasHeigth];
		}

		public Rectangle[] Rects;

		public void MathAreas ()
		{	
			Rects = new Rectangle[RectCount];

			for (int i = 0, j = 3; i < RectCount; i++)
			{
				Rects [i] = new Rectangle (aboutRect[j],aboutRect[j+1],aboutRect[j+2],aboutRect[j+3]);
				j = j + 4;
			}



		}

		public void DrawRect ()
		{

			for (int i = 0; i < Rects.Length; i++) 
			{
				for (int j = Rects[i].x1; j < Rects[i].x2; j++) 
				{
					for (int k = Rects[i].y1; k < Rects[i].y2; k++) 
					{
						CommonArea [j, k] = 1;
					}
				}
			}

		
			foreach (int elem in CommonArea)
				PaintedArea = PaintedArea + elem;
			EmptyArea = CommonArea.Length - PaintedArea;
		}


		public void WriteResult()
		{
			StreamWriter Output = File.CreateText ("OUTPUT.txt");
			Output.WriteLine ("Общий размер холста: " + CommonArea.Length);
			Output.WriteLine ("Закрашенная часть холста: " + PaintedArea);
			Output.WriteLine ("Незакрашенная часть холста: " + EmptyArea);
			Output.Close ();
		}








		public static void Main (string[] args)
		{

			Canvas FirstCanvas = new Canvas ();
			FirstCanvas.ReadInputFile ();
			FirstCanvas.MathAreas ();
			FirstCanvas.DrawRect ();
			FirstCanvas.WriteResult ();

			Console.WriteLine ("Общий размер холста: " + FirstCanvas.CommonArea.Length);
			Console.WriteLine ("Закрашенная часть холста: " + FirstCanvas.PaintedArea);
			Console.WriteLine ("Незакрашенная часть холста: " + FirstCanvas.EmptyArea);



		}
	}
}
