var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var CarSchema = new Schema({
  ID: Number,
  Producer: String,
  Type: String,
  CreationYear: Date,
  PricePerHour: Number
});

CarSchema.methods.price = new function(counthour)
{
    var result = 0;
    result = parseInt(counthour) * this.PricePerHour;
    console.log(result);
    return result;
}

mongoose.model('Car', CarSchema);