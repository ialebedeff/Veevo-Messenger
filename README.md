# Veevo Messenger

This is the complete source code and the build instructions for the alpha version of the official desktop client for the Veevo messenger, based on the Veevo API.

## Authorizatiom
![Авторизация](https://lh4.googleusercontent.com/rsbdXuDbMUKl3Va79GVZ4nBKeNY7moqhrX0H_IM3zt4vv6EURhZH1omxIakhYhfqZDnyudmcwCJtJdbnZ4Zq=w1919-h896-rw "Veevo авторизация")
## Messenger
![Мессенджер](https://lh6.googleusercontent.com/3CePRK-rhl_m8RQMODqj3KSmjF3XC1NwYioDes8ppgVbwTM9rQAPx2eKuH92PBsWS0k=w1200-h630-p "Мессенджер")
## Chat
![Чат](https://lh4.googleusercontent.com/goiyncZPMx88PWAlH3udNkbETvNnG-NhK50RBniG9QY-g7hNrebvGBYq8nuklAYS7P2OamIcf-fRuKIUquQJ=w1919-h896-rw "Чат")
## Using the API 
```C#
   // Authorization
   await VeevoAPI.LoginAsync(new LoginRequestModel(Email, Password));
   // Getting User data
    await VeevoAPI.GetMeAsync();
   // Sending a Text Message
   await VeevoAPI.SendTextMessageAsync(sendMessageTextRequestModel);
```
