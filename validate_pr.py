import re
import sys

# Constante para o padrão esperado da mensagem de commit
COMMIT_PATTERN = r'^feat\(#\d+\):\s?.*$'


def validate_commit_message(commit_message):
    """
    Valida se a mensagem de commit segue o padrão esperado.

    Args:
        commit_message (str): Mensagem de commit a ser validada.

    Returns:
        bool: True se a mensagem é válida, False caso contrário.
    """
    if re.match(COMMIT_PATTERN, commit_message):
        return True
    return False

def main():
    if len(sys.argv) < 2:
        print("Uso: python validate_commit_message.py <commit_message>")
        sys.exit(1)

    commit_message = sys.argv[1]

    if validate_commit_message(commit_message):
        print(f'Commit message "{commit_message}" válido.')
        sys.exit(0)  # Código 0 indica sucesso
    else:
        print(f'Commit message "{commit_message}" não segue o padrão esperado.')
        sys.exit(1)  # Código diferente de 0 indica falha

if __name__ == "__main__":
    main()