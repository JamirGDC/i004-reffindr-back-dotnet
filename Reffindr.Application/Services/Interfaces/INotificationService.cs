﻿using Reffindr.Domain.Models;
using Reffindr.Domain.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reffindr.Application.Services.Interfaces
{
	public interface INotificationService
	{
		Task SendNotificationAsync(Notification notification); //Envia Email

		Task AddNotificationToUser(Property property, int userSenderId);  // guarda una notificacion en un usuario
	}
}
