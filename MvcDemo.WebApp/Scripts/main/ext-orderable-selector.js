
/**=(欄位順序選擇)===============================================*/

jQuery(function ($) {

	/*紀錄欄位狀態*/
	function keepColumnStatus(orderableId, $base) {
		var columnStatus = {};
		$base.find(':checkbox').each(function () {
			var $this = $(this);
			columnStatus[$this.val()] = $this.prop('checked');
		});
		
		localStorage[orderableId] = JSON.stringify(columnStatus);		
		$base.trigger('stored.orderable', [orderableId, columnStatus]);
	}


	/*更新欄位顯示*/
	function updateColumnVisible(orderableId, targetId) {
		var columnStatus = $.parseJSON(localStorage[orderableId] || '{}');

		var temp = $.map(columnStatus, function (checked, column) {
			return checked ? null : targetId + ' .' + column;
		});

		$(orderableId).remove();

		if (temp.length === 0) { return; }
		$('<style id="' + orderableId.substr(1) + '" type="text/css">' + temp.join(', ') + '{display:none;}</style>').appendTo('head');
	}


	/*更新欄位順序*/
	function updateColumnOrder(orderableId, targetId) {
		var columnStatus = $.parseJSON(localStorage[orderableId] || '{}');
		var columns = $.map(columnStatus, function (checked, column) { return '.' + column; });
		if (columns.length == 0) { return; }

		var $target = $(targetId);
		var $trs = $target.find('tr');
		var $child = $target.children().detach(); /* 利用 detach 加快速度 */

		$trs.each(function () {
			var $tr = $(this);

			var $order = $(columns).map(function (i, col) { return $tr.find(col)[0]; });
			if ($order.length > 1) { $order.first().after($order); }
		});

		$target.append($child);
	}




	$('[ext-orderable-selector]').each(function () {
		var $base = $(this);
		var targetId = $base.attr('ext-orderable-selector');
		var orderableId = '#Orderable_' + targetId.substr(1);


		/*初始化欄位選項*/
		$(targetId).find('[ext-orderable-col]').each(function () {
			var $col = $(this);
			var colName = $col.attr('ext-orderable-col') || $col.attr('class');
			colName = colName.split(' ')[0];
			$('<li><label class="item"><input type="checkbox" value="' + colName + '" />' + $col.text() + '</label></li>').appendTo($base);
		});


		/*初始化選擇狀態*/
		if (!localStorage[orderableId]) {
			$base.find(':checkbox').prop('checked', true);
		}
		else {
			var columnStatus = $.parseJSON(localStorage[orderableId] || '{}');
			$.each(columnStatus, function (column, checked) {
				var $checkbox = $base.find(':checkbox[value="' + column + '"]');
				$checkbox.prop('checked', checked);
				$checkbox.closest('li').appendTo($base);
			});

			updateColumnOrder(orderableId, targetId);
			updateColumnVisible(orderableId, targetId);
		}


		/*欄位順序*/
		$base.sortable({
			opacity: 0.7,
			cursor: 'move',
			axis: 'y',
			update: function (e, ui) {
				keepColumnStatus(orderableId, $base);
				updateColumnOrder(orderableId, targetId);
				$base.trigger('sorted.orderable');
			}
		});


		/* 顯示/隱藏 */
		$base.change(function (e) {
			/*阻擋事件傳遞*/
			e.stopImmediatePropagation();
			e.stopPropagation();

			keepColumnStatus(orderableId, $base);
			updateColumnVisible(orderableId, targetId);
			$base.trigger('selected.orderable');
		});


		/*阻擋事件傳遞*/
		$base.click(function (e) {
			e.stopImmediatePropagation();
			e.stopPropagation();
		});
	});


	/*觸發初始完成事件*/
	setTimeout(function () {
		$('[ext-orderable-selector]').trigger('orderable-init');
	}, 100);

});
