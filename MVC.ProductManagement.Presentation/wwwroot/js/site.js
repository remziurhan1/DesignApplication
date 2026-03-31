(() => {
    function normalizeDecimalValue(value) {
        if (typeof value !== "string") {
            return value;
        }

        return value
            .replace(/\s+/g, "")
            .replace(",", ".");
    }

    function isDecimalField(input) {
        if (input.type === "number" || input.dataset.decimal === "true") {
            return true;
        }

        const name = input.getAttribute("name") || "";
        return /(Capacity|Temperature|Pressure|Cost|Price|Consumption)/i.test(name);
    }

    function getDecimalInputs(scope) {
        const inputs = scope.querySelectorAll("input");
        return Array.from(inputs).filter(isDecimalField);
    }

    function configureDecimalInputs() {
        const decimalInputs = getDecimalInputs(document);
        decimalInputs.forEach(input => {
            input.setAttribute("step", "any");
            input.setAttribute("inputmode", "decimal");

            input.addEventListener("blur", () => {
                input.value = normalizeDecimalValue(input.value);
            });
        });
    }

    document.addEventListener("submit", event => {
        const form = event.target;
        if (!(form instanceof HTMLFormElement)) {
            return;
        }

        const decimalInputs = getDecimalInputs(form);
        decimalInputs.forEach(input => {
            input.value = normalizeDecimalValue(input.value);
        });
    });

    document.addEventListener("DOMContentLoaded", configureDecimalInputs);
})();
