var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var CarSchema = new Schema({
  Name: String,
  Producer: String,
  CreationYear: Number,
  Price: Number,
  Image: String
});

CarSchema.methods.price = new function(counthour)
{
    var result = 0;
    result = parseInt(counthour) * this.Price;
    console.log(result);
    return result;
}

mongoose.model('Car', CarSchema);