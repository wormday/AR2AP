$.fn.emptySelect = function () {
    return this.each(function () {
        if (this.tagName == 'SELECT')
            this.options.length = 0;
    })
}
$.fn.loadSelect = function (optionsDataArray, textItem, valueItem) {
    return this.emptySelect().each(function () {
        if (this.tagName == 'SELECT') {
            var selectElement = this;
            $.each(optionsDataArray, function (index, optionData) {
                var option = new Option(optionData[textItem], optionData[valueItem]);
                selectElement.add(option, null);
            })
        }
    })
}
