var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Users = mongoose.model('User');

var checked = true;
var logined = false;
module.exports = function (app) 
{
  app.use('/', router);
};

router.get('/login', function (req, res, next) {
    if (req.session.IsAuthorized == true)
        res.redirect("/");
    res.render('login', {
        title: 'logined',
        check: checked,
        log: req.cookies["login"],
        pwd: req.cookies["password"],
        name: "error",
        logined: false,
        role: false
    });
});

router.post('/login',function(req,res,next)
{
    console.log("get post");
    var log = req.body.login;
    var pwd = req.body.password;
    console.log(log + " " + pwd);
    Users.findOne({Login: log}, function(err, user)
    {
        if (err)
        {
            console.log("erorr");
            return next(err);
        }
        else if (user == undefined || user == null)
        {
            console.log("not found");
            res.redirect('/login');
        }
        else if (user.Password == pwd && user.Login == log)
        {
            console.log("exist user");
            console.log(user);
            switch (user.Role) 
            {
                case 'user':
                case 'User':
                    console.log('User');
                    req.session.IsAuthorized = true;
                    req.session.UserRole = user.Role;
                    req.session.UserName = user.FirstName;
                    res.redirect('/buycar');
                    break;
                case 'admin':
                case 'Admin':
                    console.log("Admin");
                    req.session.IsAuthorized = true;
                    req.session.UserRole = user.Role;
                    req.session.UserName = user.FirstName;
                    res.redirect('/admintools');
                    break;
                case undefined:
                    console.log('undefined error');
                    checked = false;
                    res.redirect("/login");
                    break;
                default:
                    console.log('exception');
                    checked = false;
                    res.redirect("/login");
                    break;
            }
        }
        else
        {
            console.log("relog");
            checked = false;
            res.redirect("/login");
        }
    });
});
