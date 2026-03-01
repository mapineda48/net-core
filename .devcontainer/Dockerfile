# https://mcr.microsoft.com/en-us/product/dotnet/sdk/about
FROM mcr.microsoft.com/dotnet/sdk:10.0

# Install Node.js LTS + pnpm + common utilities
RUN apt-get update && apt-get install -y \
    curl \
    git \
    wget \
    unzip \
    sudo \
    && curl -fsSL https://deb.nodesource.com/setup_lts.x | bash - \
    && apt-get install -y nodejs \
    && npm install -g pnpm \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

# Create non-root dev user with passwordless sudo
ARG USERNAME=vscode

RUN groupadd $USERNAME \
    && useradd --gid $USERNAME -m $USERNAME --shell /bin/bash \
    && echo "$USERNAME ALL=(root) NOPASSWD:ALL" > /etc/sudoers.d/$USERNAME \
    && chmod 0440 /etc/sudoers.d/$USERNAME

USER $USERNAME

# Install Claude Code and make it available in PATH
RUN curl -fsSL https://claude.ai/install.sh | bash
ENV PATH="/home/${USERNAME}/.local/bin:$PATH"
