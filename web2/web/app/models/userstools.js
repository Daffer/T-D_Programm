var mongoose = require('mongoose'); 
var User = mongoose.model('User');

module.exports = 
{ 
    GetUsers: function(callback)
    {
        User.find(function(err, users)
        {
            callback(users);
        })
    },
    AddUser: function(UserToSave)
    {
        var user = new User(UserToSave);
        user.save(function(err)
        {
            if (err)
                console.log("Error to save new user");
            else
                console.log("User :" + UserToSave.FirstName + "was saved");
        });
    }
}