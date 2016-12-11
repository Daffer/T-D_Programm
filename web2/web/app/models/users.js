var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var UserSchema = new Schema({
  FirstName: String,    // Имя
  SurName: String,      // Фамилия
  SecondName: String,   // Отчество
  Sex: String,          // Пол
  DateOfBirth: String,    // Дата рождения
  Login: String,        // Login
  Password: String,     // Password
  Discount: Number,     // Скидка
  Role: String          // Роль(User,Admin)
});

UserSchema.methods.checkLogin = new function(lgn)
{
    if (lgn == this.Login)
        return true;
    else
        return false;
}

UserSchema.methods.addDiscount = new function(addedpart)
{
    this.Discount += this.Discount*addedpart; 
}

UserSchema.methods.checkPWD = new function(pwd)
{
    if (pwd == this.Password)
        return true;
    else
        return false;
}

UserSchema.methods.getPassword = new function()
{
    return this.Password;
}

UserSchema.methods.refresheDiscount = new function(price)
{
    var result = 0;
    result = price * this.Discount;
    console.log(result);
    return result;
}

mongoose.model('User', UserSchema);