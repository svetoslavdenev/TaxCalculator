const fetchSalary = () => {
    const grossAmount = document.getElementById('gross').value

    if (grossAmount === '') {
        processResponse({
            isSuccess: false,
            errorMessage: "Please provide a valid amount"
        });
        return;
    }

    const country = document.getElementById('country').value

    const url = `api/SalaryCalculator/Calculate?grossAmount=${grossAmount}&coutryId=${country}`

     fetch(url)
        .then(response => response.json())
        .then(data => processResponse(data));
}

const processResponse = result => {
    const errorWrapper = document.getElementById('error_wrapper');
    const responseWrapper = document.getElementById('response_wrapper');
    if (!result.isSuccess) {
        responseWrapper.classList.add('invisible');
        const errorText = document.getElementById('error_text');
        errorText.innerHTML = result.errorMessage;
        errorWrapper.classList.remove('invisible');
        return;
    }

    errorWrapper.classList.add('invisible');
   
    const grossResult = document.getElementById('gross_result');
    const netResult = document.getElementById('net_result');
    
    grossResult.value = `${result.data.grossAmount.totalValue} ${result.data.grossAmount.currencyISOCode}`;
    netResult.value = `${result.data.netAmount.totalValue} ${result.data.netAmount.currencyISOCode}`;
    responseWrapper.classList.remove('invisible');

    const taxesContainer = document.getElementById('taxes');
    taxesContainer.innerHTML = '';
    result.data.taxes.forEach(tax =>
    {
        let name = tax.name;
        let amount = tax.amount.totalValue;
        let currency = tax.amount.currencyISOCode;

        let divWrapper = document.createElement('div');
        divWrapper.classList.add('col-6');

        let lab = document.createElement('label');
        lab.innerHTML = name;

        let input = document.createElement('input');
        input.value = `${amount} ${currency}`
        input.classList.add('form-control');
        input.setAttribute('readonly', true);
        input.setAttribute('id', name);
        lab.setAttribute('for', name)

        divWrapper.appendChild(lab);
        divWrapper.appendChild(input);

        let line = document.createElement('hr');
        divWrapper.appendChild(line)

        taxesContainer.appendChild(divWrapper);
    })
}

