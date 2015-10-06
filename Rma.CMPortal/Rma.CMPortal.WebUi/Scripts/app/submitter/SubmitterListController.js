(function() {
	'use strict';

	window.app.controller('submitterListController', submitterListController);

	submitterListController.$inject = ['$modal', 'submitterSvc'];
	function submitterListController($modal, submitterSvc) {
		var vm = this;
		vm.add = add;
		vm.submitters = submitterSvc.submitters;


		function add() {
			$modal.open({
			    template: '<add-submitter />'
			});
		}
	}
})();