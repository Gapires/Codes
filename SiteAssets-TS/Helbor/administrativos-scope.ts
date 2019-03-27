/// <reference path="../../../../typings/index.d.ts" />
/// <reference path="../../../../typings/globals/cs/forms.d.ts" />

namespace FormularioArquivos {

  export interface FormularioArquivosScope extends CS.Forms.FormScope {
    $applyAsync(): void;
    finishLoad: () => void;   

    blockDepartamento: boolean;
    blockColab: boolean;
    RepeticaoArquivos: any[];
    blockDate: boolean;
    blockEdition: boolean;
    changeRequired: (index: number) => void;
    update: Date;
    transactionComplete: string;
    version: string;
    cancel: () => void;
    cancelCustom: () => void;
    blockRequired: boolean;
  }
}