var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var UserSchema = new Schema({
  FirstName: String,    // Имя
  SurName: String,      // Фамилия
  SecondName: String,   // Отчество
  Sex: String,          // Пол
  DateOfBirth: Date,    // Дата рождения
  Login: String,        // Login
  Password: String,     // Password
  Discount: Number,     // Скидка
  Role: String          // Роль
});

UserSchema.methods.addDiscount = new function(addedpart)
{
    this.Discount += this.Discount*addedpart; 
}

UserSchema.methods.refresheDiscount = new function(price)
{
    var result = 0;
    result = price * this.Discount;
    console.log(result);
    return result;
}

mongoose.model('User', UserSchema);