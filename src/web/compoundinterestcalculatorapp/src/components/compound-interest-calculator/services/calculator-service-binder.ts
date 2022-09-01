import { Container, getContainer } from 'inversify-props';
import Symbols from './symbols';
import { CalculatorService, CalculatorServiceImpl } from './calculator';

export class CalculatorServicesBinder {
    public static with(container: Container = getContainer()) {
        container.bind<CalculatorService>(Symbols.CalculatorServices).to(CalculatorServiceImpl).inSingletonScope();
    }
}
