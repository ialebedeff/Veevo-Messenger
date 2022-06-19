# Veevo Messenger

This is the complete source code and the build instructions for the alpha version of the official desktop client for the Veevo messenger, based on the Veevo API.

## Authorization
![Авторизация](https://lh4.googleusercontent.com/rsbdXuDbMUKl3Va79GVZ4nBKeNY7moqhrX0H_IM3zt4vv6EURhZH1omxIakhYhfqZDnyudmcwCJtJdbnZ4Zq=w1919-h896-rw "Veevo авторизация")
```C#
   // Authorization
   await VeevoAPI.LoginAsync(new LoginRequestModel(Email, Password));
 ```
## Messenger
![Мессенджер](https://lh6.googleusercontent.com/3CePRK-rhl_m8RQMODqj3KSmjF3XC1NwYioDes8ppgVbwTM9rQAPx2eKuH92PBsWS0k=w1200-h630-p "Мессенджер")
```C#
   // Getting User data
    await VeevoAPI.GetMeAsync();
 ```
## Chat
![Чат](https://lh4.googleusercontent.com/goiyncZPMx88PWAlH3udNkbETvNnG-NhK50RBniG9QY-g7hNrebvGBYq8nuklAYS7P2OamIcf-fRuKIUquQJ=w1919-h896-rw "Чат")
```C#
   // Sending a Text Message
    await VeevoAPI.SendTextMessageAsync(new SendMessageTextRequestModel() { ToUserId = 1, Text = "Привет" });
 ```
## Using the API 
```C#
   // Authorization
   await VeevoAPI.LoginAsync(new LoginRequestModel(Email, Password));
   // Getting User data
    await VeevoAPI.GetMeAsync();
   // Sending a Text Message
   await VeevoAPI.SendTextMessageAsync(new SendMessageTextRequestModel() { ToUserId = 1, Text = "Привет" });
   // Getting a Dialogs data
   await VeevoAPI.GetDialogs();
   // Creating an Account
   await VeevoAPI.CreateAccountAsync(
                            new RegistrationRequestModel()
                            {
                                Email = this.Email,
                                Password = this.Password,
                                ConfirmPassword = this.ConfirmPassword,
                            }
                        );
   // Getting User Data by Username
   await VeevoAPI.GetUserByUsernameAsync(new UserRequestModel() { Username = "#imp0$t0r"});
   // Getting User Data by Id
   await VeevoAPI.GetUserById(new UserRequestModel() { Id = 1 });
   // Getting Update Data
   await VeevoAPI.GetUpdates();
   // Getting Messages Data with current user
   await VeevoAPI.GetMessages(new GetMessagesRequestModel() { UserId = 1 });
```
