/* Use
 * $(document).on('barcodein', function (e, barcode) {
 *     console.log(e.barcode, barcode);
 * });
 */

(function (factory) {
    if ( typeof define === 'function' && define.amd ) {
        // AMD. Register as an anonymous module.
        define(['jquery'], factory);
    } else if (typeof exports === 'object') {
        // Node/CommonJS style for Browserify
        module.exports = factory;
    } else {
        // Browser globals
        factory(jQuery);
    }
}(function ($) {

	function isEnd(e) {
		return e.keyCode == 13 || e.keyCode == 9;
	}

	function trigger(el, charArray) {
		var event = $.Event("barcodein");
		event.barcode = charArray.join('');
		$(el).trigger(event, [event.barcode]);
	}


	$.event.special.barcodein = {
		setup: function () {
			var lastStamp = 0;
			var charArray = [];

			$(this).on('keyup.barcodein', function (e) {
				if (e.altKey || e.ctrlKey) { return; }

				/*檢查時間差，並回歸空值*/
				if ((e.timeStamp - lastStamp) > 100) { charArray = []; }

				/*結尾字元，以及有效資料回傳*/
				if (isEnd(e) && charArray.length > 2) {
					e.preventDefault();
					e.stopPropagation();
					trigger(this, charArray);
					return false;
				}

				/*檢查有效字元*/
				if (e.keyCode > 47 && e.keyCode < 112) {
					lastStamp = e.timeStamp;
					charArray.push(e.key);
				}
			});
		},
		teardown: function () {
			$(this).off('keyup.barcodein');
		}
	};

	$.fn.barcodein = function (fn) {
		return fn ? this.on('barcodein', fn) : this.trigger('barcodein');
	};

}));
