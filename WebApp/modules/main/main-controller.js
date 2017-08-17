(function() {
    'use strict';

    angular
        .module('app')
        .controller('MainController', MainController);

    MainController.$inject = ['$scope', '$state'];


    function MainController($scope, $state) {
        $scope.direction= function(value) {
            require(['mqtt'], function(mqtt){
                var client  = mqtt.connect('mqtt://test.mosquitto.org')
                client.on('connect', function () {
                    client.subscribe('ArduinoControl');
                    switch(value){
                    case 1:
                        client.publish('ArduinoControl', 1);
                        break;
                    case 2:
                        client.publish('ArduinoControl', 2);
                        break;
                    case 3:
                        client.publish('ArduinoControl', 3);
                        break;
                    case 4:
                        client.publish('ArduinoControl', 4);
                        break;
                    default:
                        client.publish('ArduinoControl', 0);
                    }
                })
            })
            
        }
    } 
})();