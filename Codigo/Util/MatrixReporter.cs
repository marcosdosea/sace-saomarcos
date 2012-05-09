using System;
using System.Text;
using System.IO;
using System.Diagnostics;

/// <summary>
/// Assembly that introduces dotmatrix printing support.
/// Based in JOÃO LUIS PASCOAL's JLPSay Delphi Component 
/// email: jlpascoal@uol.com.br - http://sites.uol.com.br/jlpascoal
/// 
/// Ported to .NET by Paulo Roberto Quicoli
/// email: paulo_quicoli@hotmail.com
/// Free for any usage.
/// 
/// * Jesus Christ loves you, the way you are ! *

namespace Util
{
	/// <summary>
	/// Encapsules basic formatting codes, for Epson printers,
	/// like Bold, Italic, Condensed
	/// </summary>
	public class EpsonCodes : SpecialCodes.IFormatting
	{
		private Byte[] ByteCodes;
		private string _12;
		private string _15;
		private string _18;
		private string _27;
		private string _45;
		private string _48;
		private string _50;
		private string _52;
		private string _53;
		private string _64;
		private string _67;
		private string _69;
		private string _70;
		private string _77;
		private string _80;
		private string _87;

		public EpsonCodes()
		{
			ByteCodes = new Byte[] {15,18,27,45,48,50,52,53,64,67,69,70,77,80,87,12};
			_15 = ASCIIEncoding.ASCII.GetString(ByteCodes,0,1); 
			_18 = ASCIIEncoding.ASCII.GetString(ByteCodes,1,1); 
			_27 = ASCIIEncoding.ASCII.GetString(ByteCodes,2,1); 
			_45 = ASCIIEncoding.ASCII.GetString(ByteCodes,3,1); 
			_48 = ASCIIEncoding.ASCII.GetString(ByteCodes,4,1); 
			_50 = ASCIIEncoding.ASCII.GetString(ByteCodes,5,1); 
			_52 = ASCIIEncoding.ASCII.GetString(ByteCodes,6,1); 
			_53 = ASCIIEncoding.ASCII.GetString(ByteCodes,7,1); 
			_64 = ASCIIEncoding.ASCII.GetString(ByteCodes,8,1); 
			_67 = ASCIIEncoding.ASCII.GetString(ByteCodes,9,1); 
			_69 = ASCIIEncoding.ASCII.GetString(ByteCodes,10,1); 
			_70 = ASCIIEncoding.ASCII.GetString(ByteCodes,11,1); 
			_77 = ASCIIEncoding.ASCII.GetString(ByteCodes,12,1); 
			_80 = ASCIIEncoding.ASCII.GetString(ByteCodes,13,1); 
			_87 = ASCIIEncoding.ASCII.GetString(ByteCodes,14,1); 
			_12 = ASCIIEncoding.ASCII.GetString(ByteCodes,15,1); 
		}

		public string UnderlineOn
		{
			get 
			{
				return _27 + _45 + "1";	
			}
		}
		public string UnderlineOff
		{
			get
			{
				return _27 + _45 + "0";	
			}
		}
		public string Cpi12
		{
			get { return _27 + 77; }
		}
		public string Normal
		{
			get { return _27 + _80;}
		}
		public string ItalicOn
		{
			get { return _27 + _52;}
		}
		public string ItalicOff
		{
			get { return _27 + _53; }
		}
		public string CondensedOn
		{
			get { return _15; }
		}
		public string CondensedOff
		{
			get { return _18; }
		}
		public string ExpandedOn
		{
			get { return _27 + _87 + "1"; }
		}
		public string ExpandedOff
		{
			get { return _27 + _87 + "0";}
		}
		public string BoldOn
		{
			get { return _27 + _69;}
		}
		public string BoldOff
		{
			get { return _27 + _70;}
		}
		public string Reset
		{
			get { return _27 + _64;}
		}
		public string Eject
		{
			get { return _12; }
		}
		public string SetPageSize(int Lines)
		{
			return _27 + _67 + Lines.ToString();
		}
		public string LinesInch6
		{
			get { return _27 + _50; }
		}
		public string LinesInch8
		{
			get { return _27 + _48; }
		}
	}
	/// <summary>
	/// Class for dotmatrix printing jobs.
	/// Allows simple usage, specifying line and column
	/// for a text to be printed
	/// </summary>
	public class Reporter
	{
		#region Privates Members
		
		private string FOutput;
		private string FTempFile;
		private int FCol;
		private int FRow;
		private int FCopies;
		private string InternalText;
		private bool FActive;
		private StreamWriter Arquivo;
		private Byte[] CarriageReturn;
		private Byte[] ByteCodes;
		private string _126;
		private string _8;
		private string _96;
		private string _39;
		private string _94;
		private Encoding ascii;
		#endregion

		/// <summary>
		/// Constructor which initalizes
		/// Private Members with default values
		/// </summary>
		public Reporter()
		{
			FCol = 0;
			FRow = 0;
			FCopies = 1;
			FOutput = "PRN";
			FTempFile = "Report.txt";
			CarriageReturn = new Byte[] {13};
			ByteCodes = new Byte[] {126,8,96,39,94};
			ascii = Encoding.ASCII;
			_126 = ascii.GetString(ByteCodes,0,1); 
			_8 = ascii.GetString(ByteCodes,1,1); 
			_96 = ascii.GetString(ByteCodes,2,1); 
			_39 = ascii.GetString(ByteCodes,3,1); 
			_94 = ascii.GetString(ByteCodes,4,1); 
		}

		public string CleanText(string cText)
		{
			StringBuilder s = new StringBuilder(cText);
			s = s.Replace("à",_96+_8 + "a");
			s = s.Replace("â",_94+_8 + "a");
			s = s.Replace("ê",_96+_8 + "e");
			s = s.Replace("ô",_96+_8 + "o");
			s = s.Replace("û",_96+_8 + "u");
			s = s.Replace("ã",_126+_8+"a");
			s = s.Replace("õ",_126+_8+"o");
			s = s.Replace("á",_39+_8 + "a");
			s = s.Replace("é",_39+_8 + "e");
			s = s.Replace("í",_39+_8 + "i");
			s = s.Replace("ó",_39+_8 + "o");
			s = s.Replace("ú",_39+_8 + "u");
			s = s.Replace("ç","," + _8 + "c");
			s = s.Replace("ü","u");
			s = s.Replace("À",_96+_8+"A"); 
			s = s.Replace("Â",_94+_8+"A");
			s = s.Replace("Ê",_94+_8+"E");
			s = s.Replace("Ô",_94+_8+"O");
			s = s.Replace("Û",_94+_8+"U");
			s = s.Replace("Ã",_126+_8+"A");
			s = s.Replace("Õ",_126+_8+"O");
			s = s.Replace("Á",_39+_8+"A");
			s = s.Replace("É",_39+_8 + "E");
			s = s.Replace("Í",_39+_8+"I");
			s = s.Replace("Ó",_39+_8+"O");
			s = s.Replace("Ú",_39+_8+"U");
			s = s.Replace("Ç","," + _8 + "C");
			s = s.Replace("Ü","U");
			s = s.Replace("º",".o");
			s = s.Replace("ª",".a");
			return s.ToString();
		}
		
		public bool PreviewJob()
		{
			Process p = new Process();
			p.StartInfo.FileName = "notepad.exe";
			p.StartInfo.Arguments = FTempFile;
			try
			{	p.Start();
				p = null;
				return true;
			}
			catch
			{ 
				p = null;
				return false;
			}
			
		}
		
		/// <summary>
		/// Initialize temp. file for printing.
		/// Returns True if successfull 
		/// </summary>
		public bool StartJob()
		{
			if (FActive == true)
			{
				return false;
			}
			try
			{
				FCol = 0;
				FRow = 0;
				InternalText = string.Empty;
				FActive = true;
				Arquivo = new StreamWriter(FTempFile,false,Encoding.ASCII);
				return true;
			}
			catch
			{
				FActive = false;
				return false;
			}
		}

		/// <summary>
		/// Finish temp. file for printing.
		/// </summary>
		public void EndJob()
		{
			if (FActive == true)
			{
				FActive = false;
				Arquivo.WriteLine(InternalText);
				Arquivo.Close();
			}
		}

		/// <summary>
		/// Sends temp. file to printer
		/// </summary>
		public void PrintJob()
		{
			if (FActive == true) {this.EndJob();};
			for (int i=1; i<=FCopies;i++)
			{
				File.Copy(FTempFile,FOutput,false);
			}
		}

		/// <summary>
		/// Output device for printing, including network devices.
		/// e.g. LPT1, PRN, \\Machine01\Printer1
		/// </summary>
		public string Output
		{
			get
			{
				return FOutput;
			}
			set
			{
				FOutput = value;
			}
		}

		/// <summary>
		/// Number of copies to be printed.
		/// </summary>
		public int Copies
		{
			get
			{
				return FCopies;
			}
			set
			{
				FCopies = value;
			}
		}

		/// <summary>
		/// Get/Set active row in the printing job file.
		/// </summary>
		public int Row
		{
			get
			{
				return FRow;
			}
			set
			{
				FRow = value;
			}
		}

		/// <summary>
		/// Get/Set active column int printing job file.
		/// </summary>
		public int Col
		{
			get
			{
				return FCol;
			}
			set
			{
				FCol = value;
			}
		}


		/// <summary>
		/// Sends to the printing job file any text
		/// at specified coordinates.
		/// </summary>
		/// <param name="nRow"> Row for printing the text.</param>
		/// <param name="nCol">Column for printing the text</param>
		/// <param name="cText">Text to be printed</param>
		public void PrintText(int nRow, int nCol, string cText)
		{
			if (FActive == false)
			{
				return;
			}
			if (nRow > FRow)
			{
				if (InternalText.Length > 0)
				{
					Arquivo.WriteLine(InternalText);
				}
				FRow = FRow+1;
				InternalText = string.Empty;
				for (int i=1;i<=(nRow-FRow);i++)
				{
					Arquivo.WriteLine(" ");
				}
				FRow = nRow;
				FCol = 0;
			}
			if (nRow == FRow)
			{
				if (nCol < FCol)
				{
					if (InternalText.Length > 0)
					{
						InternalText = InternalText + ASCIIEncoding.ASCII.GetString(CarriageReturn);
					}
					FCol = 0;
				}
				int i = nCol - FCol;
				InternalText = InternalText + cText.PadLeft(i + cText.Length,' ');
				FCol = FCol + cText.Length + i;
			}
		
		}

		/// <summary>
		/// Put a text into the printing job file at
		/// active row and column
		/// </summary>
		/// <param name="cText">Text to be printed</param>
		public void PutText(string cText)
		{
			this.PrintText(FRow,FCol,cText);
		}

	}

	
	namespace SpecialCodes
	{
		public interface IFormatting
		{
		}

	}
}
