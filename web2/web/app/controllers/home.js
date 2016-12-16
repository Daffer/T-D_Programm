var express = require('express');
var router = express.Router();
var mongoose = require('mongoose');
var Cars = mongoose.model('Car');
var Users = mongoose.model('User');
var Comments = mongoose.model('Comment');

module.exports = function (app) 
{
  app.use('/', router);
};

router.get('/', function (req, res, next) {
  var loginState = false;
  var username;
  var userrole;
  if (req.session.IsAuthorized != undefined && req.session.IsAuthorized != false)
  {
    loginState = true;
    username = req.session.UserName;
    userrole = req.session.UserRole;
  }
  Comments.find(function (err, findcomments) 
  {
    if (err) 
      return next(err);
    count = findcomments.length;
    res.render('index', {
      title: 'mainpage',
      comment: findcomments[0],
      countcomment: count,
      logined: loginState,
      name: username,
      role: userrole
    });
  });
});

router.post('/',function(req,res,next)
{
  req.session.IsAuthorized = undefined;
  req.session.UserName = undefined;
  req.session.UserRole = undefined;
  res.redirect("/");
});

router.get('/comments/json',function (req, res, next)
{
  console.log("get comments");
  Comments.find(function (err, findcomments)
  {
      // console.log(findcomments);
      res.status(200).send(200,{comments:findcomments});
  });
});

router.get('/setcomment',function(req, res, next)
{
  // Comments.remove({"_id": "5851b2ea79e8522f1807df62"},function(err)
  // {
  //   console.log("rem");
  // });
  // var comment = new Comments({
  //   "title":"Петрович",
  //   "text": 'Брал на лето ваз калину без ограничения территории пробега. QuickRentCar был единственным из четырёх адекватно отреагировавших контор (в трёх других всё застопорилось на этапе брони машины: не хотели чтобы в их машинах рассаду возили, хмыри). В QuickRentCar же просто заполнили заявку на сайте, очень быстро перезвонили и подтвердили бронь. Сразу погрузил лопаты и скорей на дачу. Спасибо этой компании.',
  //   "image": "img/comment-image7.jpg"
  // });
  // comment.save(function (err)
  // {
  //   console.log("save");
  // });
  Comments.find(function(err, com)
  {
    console.log(com);
  });
  res.redirect("/");
});