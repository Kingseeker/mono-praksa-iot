(function() {
    'use strict';

    var app = angular.module('app', [
    	'ngResource',
    	'ngSanitize',
      'ui.router'
    ]); 

    app.config(config);

    config.$inject = ['$stateProvider', '$httpProvider', '$locationProvider', '$urlRouterProvider', '$urlMatcherFactoryProvider'];

	function config($stateProvider, $httpProvider, $locationProvider, $urlRouterProvider, $urlMatcherFactoryProvider) {
		$httpProvider.defaults.useXDomain = true;

		delete $httpProvider.defaults.headers.common['X-Requested-With'];

		$urlRouterProvider.otherwise('/');
		$urlRouterProvider.rule(function ($injector, $location) {
			var path = $location.path(),
				normalized = path.toLowerCase();
			if (path != normalized) {
				$location.replace().path(normalized);
			}
		});
		$urlMatcherFactoryProvider.caseInsensitive(true);
		$urlMatcherFactoryProvider.strictMode(false);
		$locationProvider.html5Mode({enabled: true, requireBase: false});

    

		$stateProvider
			.state('root', {
				url: '',
				views: {
					'root': {
						templateUrl: 'modules/main/main.html',
						controller: 'MainController'
					}
				}
			})
			;
	}

	app.run(function ($state) {
		$state.go('root');
	});
})();

