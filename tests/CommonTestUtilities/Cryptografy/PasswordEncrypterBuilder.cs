﻿using Application.Services.Cryptography;

namespace CommonTestUtilities.Cryptografy
{
    public class PasswordEncrypterBuilder
    {
        public static PasswordEncripter Build() => new PasswordEncripter("abc1234");
    }
}
