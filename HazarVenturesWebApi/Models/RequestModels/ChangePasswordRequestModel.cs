﻿namespace HazarVenturesWebApi.Models.RequestModels
{
    public class ChangePasswordRequestModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
