type ErrorAlertProps = {
	message: string;
	onRetry?: () => void;
};

const ErrorAlert = ({ message, onRetry }: ErrorAlertProps) => (
	<div className="p-5 mb-6 bg-red-50 border border-red-200 rounded-xl text-red-800 flex justify-between items-center shadow-sm">
		<div className="flex items-center">
			<span className="text-xl mr-2">⚠️</span>
			<span className="font-medium">{message}</span>
		</div>
		{onRetry && (
			<button
				onClick={onRetry}
				className="ml-4 px-4 py-2 text-red-800 bg-red-100 hover:bg-red-200 rounded-lg transition-colors font-medium"
			>
				Повторить
			</button>
		)}
	</div>
);

export default ErrorAlert;
