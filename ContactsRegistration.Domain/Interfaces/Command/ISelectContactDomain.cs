﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Domain.Interfaces
{
	public interface ISelectContactDomain
	{
		ContactDomain Execute(int IdContact);
	}
}
