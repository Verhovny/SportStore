  var express = require("express"),
      app= express();

app.set("view engine", "ejs");

// app.use(express.static(__dirname + '/public'));
const path = require('path');
app.use(express.static(path.join(__dirname, 'public')));