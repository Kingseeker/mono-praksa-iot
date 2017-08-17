(function() {
  'use strict'

  var app = angular.module('roboController', []);

  $scope.direction= function(value) {
    switch(value){
      case 1:
        console.log(1);
        break;
      case 2:
        console.log(2);
        break;
      default:
        console.log("ostalo");
    }
  }
});