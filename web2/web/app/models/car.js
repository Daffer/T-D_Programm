var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var CarSchema = new Schema({
  ID: Number,           // ID
  Producer: String,     // Производитель
  Type: String,         // Тип машины
  CreationYear: Date,   // Дата производства
  PricePerHour: Number  // Стоимость аренды в час
});

CarSchema.methods.price = new function(counthour)
{
    var result = 0;
    result = parseInt(counthour) * this.PricePerHour;
    console.log(result);
    return result;
}

mongoose.model('Car', CarSchema);