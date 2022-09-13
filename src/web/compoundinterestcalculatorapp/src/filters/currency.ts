const currency = new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL',
});

export default function (value?: number) {
    if (value === undefined) {
        return value;
    }

    return currency.format(value);
}