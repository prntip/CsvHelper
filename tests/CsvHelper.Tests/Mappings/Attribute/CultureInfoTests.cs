﻿// Copyright 2009-2021 Josh Close
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using CsvHelper.Configuration.Attributes;
using Xunit;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CsvHelper.Tests.Mappings.Attribute
{
	
	public class CultureInfoTests
	{
		[Fact]
		public void CultureInfoTest()
		{
			using (var reader = new StringReader("Id,Name\r\n1,one\r\n"))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				var records = csv.GetRecords<CultureInfoTestClass>().ToList();
				var expected = CultureInfo.GetCultureInfo("jp");
				var actual = csv.Context.Maps.Find<CultureInfoTestClass>().MemberMaps[1].Data.TypeConverterOptions.CultureInfo;

				Assert.Equal(expected, actual);
			}
		}

		private class CultureInfoTestClass
		{
			public int Id { get; set; }

			[CultureInfo("jp")]
			public string Name { get; set; }
		}
	}
}
