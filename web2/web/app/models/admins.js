var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var AdminSchema = new Schema({
  ID: Number,
  Name: String,         // Имя
  Login: String,        // Login
  Password: String,     // Password
});

AdminSchema.methods.checkLogin = new function(lgn)
{
    if (lgn == this.Login)
        return true;
    else
        return false;
}

AdminSchema.methods.checkPWD = new function(pwd)
{
    if (pwd == this.Password)
        return true;
    else
        return false;
}

AdminSchema.methods.getPassword = new function()
{
    return this.Password;
}

mongoose.model('Admin', AdminSchema);